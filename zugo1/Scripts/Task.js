class page{
    constructor() {
        console.log("Task/Add")
        this.inputs=[]
    }
    configureEvents() {
        const id = document.querySelector("input[name='id']");
        const taskDescription = document.querySelector("input[name='taskDescription']");
        const taskDate = document.querySelector("input[name='taskDate']");
        const submitTask = document.querySelector("button.submitTask");
        this.inputs = [id, taskDescription,taskDate];
        submitTask.addEventListener("click", () => {
           const data = pg.inputs.reduce((acc, i) => {
                acc[i.name] = i.value;
                return acc;
            }, {})
            const httpReq = {
                method: "POST",
                headers: {
                    "Content-Type": "application/json"
                },
                body: JSON.stringify(data)
            }
            console.log(httpReq)

            fetch("/Task/PostTask", httpReq)
                .then(resp => resp.json)
                .then(r => {
                    if (r.success) {
                        console.log("Added Successfully");
                    } else {
                        console.log(r.message);
                    }
                })
                .catch(e => {
                        console.error("Server Connection Error");
                })

        })

    }
}