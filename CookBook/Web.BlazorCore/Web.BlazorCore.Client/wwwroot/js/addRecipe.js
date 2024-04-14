function handleImgClicked() {
    const fileInput = document.getElementById("recipe-img-selector");

    fileInput.click()
}

function addTestEvent() {
    const ingeredientAmountInput = document.getElementById("ingeredient-amount-input");

    ingeredientAmountInput.addEventListener("change", () => console.log("input changed"))
}

const isNumber = (value) => {
    return typeof value == number;
}

const isValidNumber = (value) => {
    return isNumber(value) && value > 0
}

const hasRequiredLength = (value, length) => {
    return value.length >= length
}

const toggleIngredientButtonDisabled = () => {
    const ingeredientAmountInput = document.getElementById("ingeredient-amount-input");
    const ingredientUnitInput = document.getElementById("ingredient-unit-input");
    const ingredientNameInput = document.getElementById("ingredient-name-input");
    const ingredientCategoryInput = document.getElementById("ingredient-category-input");
    const addIngredientButton = document.getElementById("add-ingredient-btn");

    if (ingeredientAmountInput === undefined ||
        ingredientUnitInput === undefined ||
        ingredientNameInput === undefined ||
        ingredientCategoryInput === undefined ||
        addIngredientButton === undefined) {

        return;
    }

    if (isValidNumber(ingeredientAmountInput.nodeValue) && hasRequiredLength(ingredientNameInput, 2)) {

        if (addIngredientButton.classList.contains("dieabled")) {
            addIngredientButton.classList.remove("disabled")


        }

        return;
    }

    addIngredientButton.classList.add("disabled")
}

const disableAddIngredientButton = () => {
    const addIngredientButton = document.getElementById("add-ingredient-btn");

    addIngredientButton.classList.add("disabled");
}

const addEventListener = (element) => {
    element.addEventListener("change", toggleIngredientButtonDisabled);
}




