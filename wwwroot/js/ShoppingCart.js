// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener('load', () => {


    try {
        // Add event listeners to all the remove buttons on the page,
        // and pass in the cart id to the function that will be called on the event.
        let deleteBtns = document.querySelectorAll('#cartDelete');

        deleteBtns.forEach((btn => btn.addEventListener('click', () => DeleteCart(btn.getAttribute('cartId')))));

    }
    catch {
        console.log("error setting delete button event handlers")
    }

    try {
        // Add event listeners to all the select buttons on the page,
        // and pass in the cart id to the function that will be called on the event.
        let selectBtns = document.querySelectorAll('#cartSelect');

        selectBtns.forEach((btn => btn.addEventListener('click', () => loadShoppingCartItems(btn.getAttribute('cartId')))));
    }
    catch {
        console.log("error adding cart select event")
    }


    // Add an event listener to the new shopping cart button so the user can make new carts.
    document.getElementById("btnListCreate").addEventListener('click', () => {
        NewShoppingList();
    });
});



async function loadShoppingCartItems(cartId)
{
    //update the user's selected cart.
    await fetch(`ShoppingCart/UpdateSelectedCart?cartId=${cartId}`, {
        method: 'PUT',
        headers: {
            "content-type": "application/json"
        }
    });

    // Make the url for the get cart contents request
    let URL = "/ShoppingCart/GetCartContents";

    let fullURL = `${URL}?cartId=${cartId}`;


    // Tell the controller to create a new view containing all the items of the current cart.
    let cartItems = await fetch(fullURL)

    let cardHolder = document.getElementById("cardHolder");

    cardHolder.innerHTML = await cartItems.text();

    // Add the script which allows for item adding/removing in the modal.
    let modelScript = document.createElement('script');
    modelScript.src = "/js/ItemManager.js";
    document.body.append(modelScript);
                
}
    
async function NewShoppingList() {

    // Get the name of the shopping cart the user gave it.
    let listName = document.getElementById("newListName").value;

    let URL = "/ShoppingCart/MakeNewShoppingCart";
        
    let fullURL = `${URL}?cartName=${listName}`;


    // Tell the controller to add the new cart.
    await fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json"
        }

    });

    location.reload();

}

async function DeleteCart(cartId) {

    let URL = "/ShoppingCart/DeleteShoppingCart";

    let fullURL = `${URL}?cartId=${cartId}`;


    // Tell the controller to add the new cart.
    await fetch(fullURL, {
        method: 'DELETE',
        headers: {
            "content-type": "application/json"
        }

    });

    location.reload();
}

