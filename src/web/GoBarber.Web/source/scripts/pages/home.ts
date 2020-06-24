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
    }

    init() {
    }
}

new Home();