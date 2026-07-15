document.querySelectorAll("[data-counter-for]").forEach((counter) => {
    const field = document.getElementById(counter.dataset.counterFor);

    if (!field) {
        return;
    }

    const updateCounter = () => {
        counter.textContent = `${field.value.length}/${field.maxLength}`;
    };

    field.addEventListener("input", updateCounter);
    updateCounter();
});
