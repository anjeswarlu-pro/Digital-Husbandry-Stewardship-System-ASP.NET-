from flask import Flask, request, jsonify
from flask_cors import CORS
import pickle
import numpy as np

app = Flask(__name__)
CORS(app, origins="*")
# Load the model and scalers
model = pickle.load(open('model.pkl', 'rb'))
minmaxscaler = pickle.load(open('minmaxscaler.pkl', 'rb'))
standscaler = pickle.load(open('standscaler.pkl', 'rb'))

@app.route('/predict', methods=['POST'])
def predict():
    try:
        print("Prediction request received")
        data = request.get_json()
        print("Received data:", data)
        # Extract input features
        N = data['N']
        P = data['P']
        k = data['k']
        temperature = data['temperature']
        humidity = data['humidity']
        ph = data['ph']
        rainfall = data['rainfall']

        # Prepare input features
        features = np.array([[N, P, k, temperature, humidity, ph, rainfall]])
        print("done features")
        transformed_features = minmaxscaler.transform(features)
        print("transformed_features")
        transformed_features = standscaler.transform(transformed_features)
        print("done step 3")
        # Make prediction
        prediction = model.predict(transformed_features).reshape(1, -1)
        print(prediction)
        # Map prediction to crop name
        crop_dict = {1: "Rice", 2: "Maize", 3: "Jute", 4: "Cotton", 5: "Coconut", 6: "Papaya", 7: "Orange",
                     8: "Apple", 9: "Muskmelon", 10: "Watermelon", 11: "Grapes", 12: "Mango", 13: "Banana",
                     14: "Pomegranate", 15: "Lentil", 16: "Blackgram", 17: "Mungbean", 18: "Mothbeans",
                     19: "Pigeonpeas", 20: "Kidneybeans", 21: "Chickpea", 22: "Coffee"}

        result = {'The Crop is:':crop_dict[prediction[0][0]]}

        return jsonify(result)
    except Exception as e:
        print("Error:", e)
        return jsonify({'error': str(e)}), 500

if __name__ == '__main__':
    app.run(port=5000)