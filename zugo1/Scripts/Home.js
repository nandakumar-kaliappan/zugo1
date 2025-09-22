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
                } else {
                    console.error(r.message);
                }
            })
            .catch(e => {
                console.error("Server Connection Error");
            })


    }
}