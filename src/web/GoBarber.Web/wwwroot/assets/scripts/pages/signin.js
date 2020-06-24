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
        this.inputEmail = document.querySelector(".input-email");
        this.inputPassword = document.querySelector(".input-password");
        this.init();
    }
    init() {
        window.localStorage.removeItem("GoBarber.Web:Token");
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
            this.btnDoLogin.disabled = true;
            this.btnDoLogin.textContent = "Loading...";
            yield this.doLogin();
        });
    }
    doLogin() {
        return __awaiter(this, void 0, void 0, function* () {
            try {
                let data = {
                    email: this.inputEmail.value,
                    password: this.inputPassword.value,
                };
                const rawResponse = yield fetch("https://localhost:3333/signin", {
                    method: "POST",
                    headers: {
                        Accept: "application/json",
                        "Content-Type": "application/json",
                    },
                    body: JSON.stringify(data),
                });
                let response = yield rawResponse.json();
                debugger;
                if (response.success) {
                    window.localStorage.setItem("GoBarber.Web:Token", `Bearer ${response.user.token}`);
                    document.location.href = "/home";
                }
            }
            catch (e) {
            }
            finally {
                this.btnDoLogin.disabled = false;
                this.btnDoLogin.textContent = "Login";
            }
        });
    }
}
new SignIn();
