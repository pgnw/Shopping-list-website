startUp();


async function startUp() {
    try {
        // Add event listeners to all the add and remove buttons on the page.
        let addBtns = document.querySelectorAll('[id$="btnAdd"]');

        addBtns.forEach((btn => btn.addEventListener('click', (e) => addItem(btn.getAttribute('itemId'),e))));
    }
    catch {
        console.log("error setting item add button event handlers")
    }

    try {
        let removeBtns = document.querySelectorAll('#btnRemove');

        removeBtns.forEach((btn => btn.addEventListener('click', (e) => removeItem(btn.getAttribute('itemId'),e))));
    }
    catch {
        console.log("error setting item remove button event handlers")
    }
}

async function addItem(itemId, e) {
    // Build a URL to send a request to the controller to add a new item.
    let URL = "/ShoppingCart/AddItem";

    let fullURL = `${URL}?itemId=${itemId}`;

    // Tell the controller to add the item.
    fetch(fullURL, {
        method: 'POST',
        headers: {
            "content-type": "application/json"
        }

    });

    // Update the cart modal on screen.
    updateCartModal(1, e);
}

async function removeItem(itemId, e) {
    // Build a URL to send a request to the controller to remove a item.
    let URL = "/ShoppingCart/RemoveItem";

    let fullURL = `${URL}?itemId=${itemId}`;

    // Tell the controller to remove the item.
    fetch(fullURL, {
        method: 'DELETE',
        headers: {
            "content-type": "application/json"
        }
    });

    // Update the cart modal on screen.
    updateCartModal(-1, e);
}

async function updateCartModal(amount, e) {

    // This is the button that triggered the event, which will be either the add button or the remove button.
    let sourceBtn = e.target;

    // Go through the siblings backwards untill the hidden quantity element is reached.
    var sibling = sourceBtn.previousElementSibling;
    while (sibling && sibling.id !== 'Quantity') {
        sibling = sibling.previousElementSibling;
    }

    // Get the quantity value from the sibling element.
    let quantity = parseInt(sibling.value);

    // Change the value amount of the hidden quantity field based on amount which will either be 1 or -1.
    sibling.value = quantity + amount;
    // Update the quantity now.
    quantity = sibling.value;

    // The code below will adjust the total price by the item being added/removed.

    // Go backwards through the sibling elements until the price hidden input.
    sibling = sourceBtn;
    while (sibling && sibling.id !== 'Price') {
        sibling = sibling.previousElementSibling;
    }

    // Get the price of the item
    let price = parseFloat(sibling.value);

    // Get the total price of all the items
    let totalPriceElement = document.getElementById("TotalPriceValue");
    let totalPrice = parseFloat(totalPriceElement.innerHTML);

    // Calculate the new total price.
    let newTotalPrice = totalPrice + (price * amount);

    // Fix any weird number problems.
    if (newTotalPrice < 0)
        newTotalPrice = 0;

    // Update the new price to screen, with just 2 decimal values.
    totalPriceElement.innerHTML = newTotalPrice.toFixed(2);


    // This code updates the quantity on the modal or if the quantity is 0, it removes the row of the item.

    if (quantity >= 1) {
        // Find the quantity display element this time
        sibling = sourceBtn.previousElementSibling;
        while (sibling && sibling.id !== 'QuantityDisplay') {
            sibling = sibling.previousElementSibling;
        }
        // Update the text of the quantity display element
        sibling.innerHTML = `Amount: ${quantity}`;
    }
    // If there is zero or less of an item remove it from the screen.
    else {

        // Go up by three levels to find the row class for the item then delete it.
        let row = sourceBtn.parentNode.parentNode.parentNode;
        row.remove();
    }
}

