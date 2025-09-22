function loadRelevantFiles(pageName) {
    loadJs(`/Scripts/${pageName}.js`, () => {
        let p = new page(pageName);
    });
}

function loadJs(filePath, cbFunction) {
    const js = document.createElement("script");
    js.src = filePath;
    js.async = true;
    js.onload = cbFunction;
    js.onerror = () => {
        console.log(`Could not load ${filePath}`);
    }
    document.querySelector("body").insertAdjacentElement("beforeend",js);
}