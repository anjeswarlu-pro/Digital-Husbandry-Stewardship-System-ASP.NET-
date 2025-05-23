// Initialize the carousel
$('.carousel').carousel({
    interval: 2500, // Change interval as needed (in milliseconds)
    wrap: false // Prevents carousel from wrapping around
});

function toggleDashboardPanel() {
    console.log("Toggling dashboard panel...");
    var panel = document.querySelector(".dashboard-panel");
    panel.classList.toggle("open");
}


$(document).ready(function () {
    var currentSlide = 0;
    var slides = $('.slides').children('.slide');
    var totalSlides = slides.length;

    function showSlide(index) {
        slides.removeClass('active');
        slides.eq(index).addClass('active');
    }

    function nextSlide() {
        currentSlide = (currentSlide + 1) % totalSlides;
        showSlide(currentSlide);
    }

    function prevSlide() {
        currentSlide = (currentSlide - 1 + totalSlides) % totalSlides;
        showSlide(currentSlide);
    }

    $('.next-slide').click(nextSlide);
    $('.prev-slide').click(prevSlide);

    // Automatic slideshow
    setInterval(nextSlide, 3000); // Change slide every 3 seconds
});
function toggleDataColumn() {
    var ddl2 = document.getElementById("DropDownList2");
    var dataColumn = document.querySelector(".data-column");
    if (ddl2.selectedIndex !== 0) {
        dataColumn.style.display = "block";
    } else {
        dataColumn.style.display = "none";
    }
}
function validateInput(input, min, max) {
    var value = parseInt(input.value);

    if (isNaN(value)) {
        alert("Enter a valid numeric value for " + input.id);
        return false;
    } else if (value < min || value > max) {
        alert("Enter a value between " + min + " and " + max + " for " + input.id);
        return false;
    }

    return true;
}
// Mapping of crop names to image paths

// Function to validate input values
function validateInput(inputElement, minValue, maxValue) {
    var value = parseInt(inputElement.value);
    if (isNaN(value) || value < minValue || value > maxValue) {
        alert("Invalid input for " + inputElement.id);
        return false;
    }
    return true;
}

// Function to handle the prediction result
function handlePredictionResult(resultMessage) {
    var cropName = getCropNameFromMessage(resultMessage);
    if (cropName) {
        displayCropImage(cropName);
    } else {
        console.error("Failed to extract crop name from the result message:", resultMessage);
    }
}

// Function to send prediction request
function predict() {
    // Validate input values
    var inputRanges = {
        'N': { min: 5, max: 150 },
        'P': { min: 5, max: 150 },
        'k': { min: 5, max: 200 },
        'temperature': { min: 7, max: 40 },
        'humidity': { min: 40, max: 90 },
        'ph': { min: 1, max: 12 },
        'rainfall': { min: 80, max: 250 }
    };

    for (var inputId in inputRanges) {
        var inputElement = document.getElementById(inputId);
        var range = inputRanges[inputId];
        if (!validateInput(inputElement, range.min, range.max) && inputId !== 'ph') {
            return; // Stop execution if any input is invalid
        }
    }


    // Prepare data for prediction
    var formData = new FormData(document.getElementById('User'));
    var requestData = {
        N: formData.get('N'),
        P: formData.get('P'),
        k: formData.get('k'),
        temperature: formData.get('temperature'),
        humidity: formData.get('humidity'),
        ph: formData.get('ph'),
        rainfall: formData.get('rainfall')
    };

    // Send prediction request
    $.ajax({
        type: "POST",
        url: "User.aspx/predict",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(requestData),
        dataType: "json",
        success: function (result) {
            if (result.hasOwnProperty('error')) {
                alert(result.error); // Display error message if any
            } else {
                var resultMessage =result.d;
                document.getElementById('predictionResult').textContent = resultMessage; // Display result message
                handlePredictionResult(resultMessage); // Handle prediction result
            }
        },
        error: function (xhr, status, error) {
            console.log('Error occurred during prediction:', error);
        }
    });
}

// Function to extract crop name from the result message
function getCropNameFromMessage(message) {
    try {
        var resultObject = JSON.parse(message);
        return resultObject['The Crop is:'];
    } catch (error) {
        console.error("Error parsing JSON:", error);
        return null;
    }
}

// Function to display crop image based on crop name
function displayCropImage(cropName) {
    var imagePath = cropImageMap[cropName];
    if (imagePath) {
        var imageElement = document.createElement("img");
        imageElement.src = imagePath;
        imageElement.alt = cropName;
        var imageContainer = document.querySelector(".image");
        imageContainer.innerHTML = ""; // Clear previous image
        imageContainer.appendChild(imageElement);
    } else {
        console.error("Image path not found for crop:", cropName);
    }
}

// Crop image map
var cropImageMap = {
    "Rice": "imges/Rice.jpg",
    "Maize": "imges/Maize.jpg",
    "Jute": "imges/Jute.jpg",
    "Cotton": "imges/Cotton.jpg",
    "Coconut": "imges/Coconut.jpg",
    "Papaya": "imges/Papaya.jpg",
    "Orange": "imges/Orange.jpg",
    "Apple": "imges/Apple.jpg",
    "Muskmelon": "imges/Muskmelon.jpg",
    "Watermelon": "imges/Watermelon.jpg",
    "Grapes": "imges/Grapes.jpg",
    "Mango": "imges/Mango.jpg",
    "Banana": "imges/Banana.jpg",
    "Pomegranate": "imges/Pomegranate.jpg",
    "Lentil": "imges/Lentil.jpg",
    "Blackgram": "imges/Blackgram.jpg",
    "Mungbean": "imges/Mungbean.jpg",
    "Mothbeans": "imges/Mothbeans.jpg",
    "Pigeonpeas": "imges/Pigeonpeas.jpg",
    "Kidneybeans": "imges/Kidneybeans.jpg",
    "Chickpea": "imges/Chickpea.jpg",
    "Coffee": "imges/Coffee.jpg",
    "Default": "imges/6.jpg" // Default image path
};

// Event listener for prediction button
document.getElementById('predictButton').addEventListener('click', predict);
$(document).ready(function () {
    $('#informationBtn').click(function (event) {
        event.preventDefault(); // Prevent the default behavior of the button
        console.log("Button clicked"); // Check if the button click event is triggered
        var navBarHeight = 50; // Adjust this value according to the height of your navigation bar
        var spaceBelowNavBar = 40; // Adjust this value according to the desired space below the navigation bar
        var offset = $('.information-section').offset().top - navBarHeight - spaceBelowNavBar; // Subtract the navigation bar height and space below from the top position of the information section
        console.log('Offset:', offset); // Check the offset value
        $('html, body').animate({
            scrollTop: offset
        }, 1000);
    });
});
