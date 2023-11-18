// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {
    try {
        //Add an event listener to the component specified to manage click events
        document.getElementById("btnCartShow").addEventListener('click', () => {
            showCartModal();
        });

        // When the modal is shown load up the item manager script so the modal buttons work.
        document.getElementById("mCart").addEventListener('shown.bs.modal', () => {
            let modelScript = document.createElement('script');
            modelScript.src = "/js/ItemManager.js";
            document.body.append(modelScript);
        })
    }
    catch {
        console.log("tried to find btnCartShow but couldn't")
    }


})

async function showCartModal() {
    // Get the modal from the controller.
    let modalPage = await fetch("/Shoppingcart/GetPartialCartItems");
    let modalText = await modalPage.text();

    // Add the html text to the modal
    modalContent = document.getElementById("mCartContent");
    modalContent.innerHTML = modalText;

    // Show the modal.
    $("#mCart").modal("show");


}