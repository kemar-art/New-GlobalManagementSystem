const openPopButtons = document.querySelectorAll('[data-pop-target]')
const closePopButtons = document.querySelectorAll('[data-close-button]')
const overlay = document.getElementById('overlay')

openPopButtons.forEach(button => {
    button.addEventListener('click', () => {
        const pop = document.querySelector(button.dataset.popTarget)
        openPop(pop)
    })
})

overlay.addEventListener('click', () => {
    const items = document.querySelectorAll('.item.active')
    items.forEach(item => {
        closePop(item)
    })
})

closePopButtons.forEach(button => {
    button.addEventListener('click', () => {
        const pop = button.closest('.item')
        closePop(pop)
    })
})

function openPop(pop) {
    if (pop == null) return
    pop.classList.add('active')
    overlay.classList.add('active')
}

function closePop(pop) {
    if (pop == null) return
    pop.classList.remove('active')
    overlay.classList.remove('active')
}
