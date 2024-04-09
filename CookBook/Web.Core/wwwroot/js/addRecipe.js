const fileInput = document.getElementById("recipe-img-selector");
const previewImage = document.getElementById("recipe-preview-img")

fileInput.addEventListener("change", (e) => {
    const file = e.target.files[0];

    if (file !== undefined) {

        const reader = new FileReader();

        reader.onload = (e) => {
            previewImage.setAttribute("src", e.target.result)
        }

        reader.readAsDataURL(file);
    }
})

previewImage.addEventListener("click", () => {
    fileInput.click()
});
