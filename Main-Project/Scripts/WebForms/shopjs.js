
function toggleDashboardPanel() {
    console.log("Toggling dashboard panel...");
    var panel = document.querySelector(".dashboard-panel");
    panel.classList.toggle("open");
}
function openCartPopup() {
    // Change the URL to the location of the webpage you want to load
    var iframeUrl = "cart.aspx";

    // Create iframe element
    var iframe = document.createElement("iframe");
    iframe.src = iframeUrl;
    iframe.width = "100%";
    iframe.height = "100%";
    iframe.frameBorder = 0;

    // Create close button
    var closeBtn = document.createElement("span");
    closeBtn.innerHTML = "&times;";
    closeBtn.className = "close-btn";
    closeBtn.onclick = closeCartPopup;

    // Append iframe and close button to the container
    var iframeContainer = document.getElementById("iframeContainer");
    iframeContainer.appendChild(iframe);
    iframeContainer.appendChild(closeBtn);

    // Show the container
    iframeContainer.style.display = "block";
}

function closeCartPopup() {
    // Remove iframe from container
    var iframeContainer = document.getElementById("iframeContainer");
    while (iframeContainer.firstChild) {
        iframeContainer.removeChild(iframeContainer.firstChild);
    }

    // Hide the container
    iframeContainer.style.display = "none";
}


