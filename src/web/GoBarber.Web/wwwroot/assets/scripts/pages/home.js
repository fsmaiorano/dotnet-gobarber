var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class Home {
    constructor() {
        this.appointments = document.querySelector(".appointmentsk");
        this.init();
        this.getAppointments();
    }
    init() {
    }
    getAppointments() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let token = window.localStorage.getItem("GoBarber.Web:Token");
                const rawResponse = yield fetch('/appointment', {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                        "Content-Type": "application/json",
                        token: `${token}`,
                    },
                });
                debugger;
            }
            catch (e) {
                console.error(e);
            }
        });
    }
}
new Home();
