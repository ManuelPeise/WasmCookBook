function isNumber(value) {
    var stringValue = String(value);

    if (stringValue.length >= 1 && stringValue.endsWith('.') || stringValue.endsWith(',')) {
        return true;
    }

    var decimalExp = /^[-+]?[0-9]+\.[0-9]+$/;
    var numberExp = /^[0-9]+$/;
    var decimalRegex = new RegExp(decimalExp)
    var numberRegex = new RegExp(numberExp)

    return decimalRegex.test(value) || numberRegex.test(value)
};

function handleResetInputField(id) {
    const element = document.getElementById(id)

    if (element !== undefined) {
        element.value = ""
    }
};

function handleNumberInputValidation(value, id, error) {
    console.log("validate input...")

    var errorElement = document.getElementById(id + "-error");

    if (errorElement == undefined) {
        console.log("could not founf error element")
    } else {
        errorElement.innerHTML = ""
    }

    if (value === "") {
        errorElement.innerHTML = ""
        return;
    }

    if (!isNumber(value)) {

        if (errorElement !== undefined) {
            errorElement.innerHTML = error
        }
    }
};

function handleValidateTextFieldInput(value, id, error) {
    var errorElement = document.getElementById(id + "-error");

    if (errorElement !== undefined) {
        errorElement.innerHTML = ""
    }

    if (value == "" && errorElement !== undefined) {
        errorElement.innerHTML = error
    }
}

function handleValidateDropdownInput(value, id, error) {
    var errorElement = document.getElementById(id + "-error");

    if (errorElement !== undefined) {
        errorElement.innerHTML = ""
    }

    if (value == "0" && errorElement !== undefined) {
        errorElement.innerHTML = error
    }
}

function handleImgClicked(id) {
    const fileInput = document.getElementById(id);

    fileInput.click()
}




