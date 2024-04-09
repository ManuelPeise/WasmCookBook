const toggler = document.querySelector(".btn");
toggler.addEventListener("click", () => {
    document.querySelector("#sidebar").classList.toggle("collapsed")
})

const handleClick = (e) => {
    console.log("link clicked")
    e.classList.toggle(".link-disabled")
}



