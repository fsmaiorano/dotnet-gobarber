var __awaiter = (this && this.__awaiter) || function (thisArg, _arguments, P, generator) {
    function adopt(value) { return value instanceof P ? value : new P(function (resolve) { resolve(value); }); }
    return new (P || (P = Promise))(function (resolve, reject) {
        function fulfilled(value) { try { step(generator.next(value)); } catch (e) { reject(e); } }
        function rejected(value) { try { step(generator["throw"](value)); } catch (e) { reject(e); } }
        function step(result) { result.done ? resolve(result.value) : adopt(result.value).then(fulfilled, rejected); }
        step((generator = generator.apply(thisArg, _arguments || [])).next());
    });
};
class SignIn {
    constructor() {
        this.btnDoLogin = document.querySelector(".btn-login");
        this.frmLogin = document.querySelector(".form");
        this.inputEmail = document.querySelector(".input-email");
        this.inputPassword = document.querySelector(".input-password");
        this.init();
    }
    init() {
        this.inputEmail.addEventListener("change", (event) => {
            let input = event.target;
            if (input.value !== "") {
                input.parentElement.classList.add("input-focused");
            }
            else {
                input.parentElement.classList.remove("input-focused");
            }
        });
        this.inputPassword.addEventListener("change", (event) => {
            let input = event.target;
            if (input.value !== "") {
                input.parentElement.classList.add("input-focused");
            }
            else {
                input.parentElement.classList.remove("input-focused");
            }
        });
        this.btnDoLogin.onclick = () => __awaiter(this, void 0, void 0, function* () {
            debugger;
            var opts = {
                method: "POST",
                headers: new Headers({
                    Accept: "application/json",
                    "Content-Type": "application/json",
                }),
                mode: "no-cors",
                body: JSON.stringify({
                    email: this.inputEmail,
                    password: this.inputEmail,
                    token: "",
                }),
            };
            yield fetch("https://localhost:5001/api/Authentication", opts)
                .then(function (response) {
                debugger;
                return response.json();
            })
                .then(function (body) {
                debugger;
                //doSomething with body;
            });
        });
    }
}
new SignIn();
