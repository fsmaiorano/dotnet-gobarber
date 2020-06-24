interface LoginResponse extends GenericResult {
    success: boolean,
    user: {
        token
    }
}

class Home {
    private appointments: HTMLDivElement = document.querySelector(".appointmentsk");

    constructor() {
        this.init();
        this.getAppointments();
    }

    init() {
    }

    async getAppointments() {
        try {
            let token = window.localStorage.getItem("GoBarber.Web:Token");
            const rawResponse = await fetch('/appointment', {
                method: "GET",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                    token: `${token}`,
                },
            });

            debugger;
            

        } catch (e) {
            console.error(e)
        }
        
    }
}

new Home();