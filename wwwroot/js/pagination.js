// pagination.js
// Universal pagination for lists and tables
// Usage: setupPagination(selectorForItems, selectorPrevArrow, selectorNextArrow, itemsPerPage);

function setupPagination(itemSelector, prevArrowSelector, nextArrowSelector, itemsPerPage = 5) {
    const items = document.querySelectorAll(itemSelector);
    if (!items.length) return; // nothing to paginate

    let currentPage = 0;
    const prevArrow = document.querySelector(prevArrowSelector);
    const nextArrow = document.querySelector(nextArrowSelector);

    function showPage(page) {
        items.forEach((item, index) => {
            // If the element is a <tr>, use table-row display; otherwise, fallback to block.
            const isTableRow = item.tagName.toLowerCase() === "tr";
            const show = index >= page * itemsPerPage && index < (page + 1) * itemsPerPage;
            item.style.display = show ? (isTableRow ? "table-row" : "block") : "none";
        });
    }

    function updateArrows() {
        if (prevArrow) prevArrow.style.opacity = currentPage === 0 ? "0.3" : "1";
        if (nextArrow) nextArrow.style.opacity = ((currentPage + 1) * itemsPerPage >= items.length) ? "0.3" : "1";
    }

    if (prevArrow) {
        prevArrow.addEventListener("click", () => {
            if (currentPage > 0) {
                currentPage--;
                showPage(currentPage);
                updateArrows();
            }
        });
    }

    if (nextArrow) {
        nextArrow.addEventListener("click", () => {
            if ((currentPage + 1) * itemsPerPage < items.length) {
                currentPage++;
                showPage(currentPage);
                updateArrows();
            }
        });
    }

    // Initialize
    showPage(0);
    updateArrows();
}
