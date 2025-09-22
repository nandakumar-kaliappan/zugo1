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
            console.log( data)
        })

    }
}