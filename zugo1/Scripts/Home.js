class page {
    constructor() {
        console.log("Home")
        this.inputs = []
    }
    configureEvents() {
        const httpReq = {
            method: "GET",
        }

        fetch("/Task/GetTasks", httpReq)
            .then(resp => resp.json())
            .then(r => {
                if (r.success) {
                    console.log(r.data);
                    const tableBody = document.querySelector("table#tblTask tbody")
                    tableBody.innerHTML = pg.getTableHTML(r.data);


                } else {
                    console.error(r.message);
                }
            })
            .catch(e => {
                console.error("Server Connection Error");
            })


    }

    getTableHTML(data) {
        const wrapTr = (v) => `<tr>${v}</tr>`
        const wrapTd = (v) => `<td>${v}</td>`
        const wrapBtn = (v) => `<button type = "button" onclick=" pg.deleteTask(${v})">Delete</button>`
        return data
            .map((r, i) => `${wrapTd(i + 1)} ${wrapTd(r.taskDescription)} ${wrapTd(r.taskDate)} ${wrapTd(wrapBtn(r.id))}`)
            .map(r => `${wrapTr(r)}`)
            .join('');
    }
    deleteTask(id) {
        const httpReq = {
            method: "GET",
        }

        fetch(`/Task/DeleteTask/${id}`, httpReq)
            .then(resp => resp.json())
            .then(r => {
                if (r.success) {
                    window.location = "/"
                } else {
                    console.error(r.message);
                }
            })
            .catch(e => {
                console.error("Server Connection Error");
            })
    }

}