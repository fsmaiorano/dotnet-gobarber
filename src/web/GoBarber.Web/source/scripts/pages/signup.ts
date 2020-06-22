interface ICreateUser {
    name: string;
    email: string;
    password: string;
    avatar: string;
    role: string;
}

interface LoginResponse extends GenericResult {
    token: string;
}

class SignUp {
    private btnDoCreateUser: HTMLButtonElement = document.querySelector(
        ".btn-login"
    );
    private inputUser: HTMLInputElement = document.querySelector(".input-user");
    private inputEmail: HTMLInputElement = document.querySelector(".input-email");
    private inputPassword: HTMLInputElement = document.querySelector(
        ".input-password"
    );

    constructor() {
        this.init();
    }

    init() {
        this.inputUser.addEventListener("change", (event: Event) => {
            let input = event.target as HTMLInputElement;

            if (input.value !== "") {
                input.parentElement.classList.add("input-focused");
            } else {
                input.parentElement.classList.remove("input-focused");
            }
        });

        this.inputEmail.addEventListener("change", (event: Event) => {
            let input = event.target as HTMLInputElement;

            if (input.value !== "") {
                input.parentElement.classList.add("input-focused");
            } else {
                input.parentElement.classList.remove("input-focused");
            }
        });

        this.inputPassword.addEventListener("change", (event: Event) => {
            let input = event.target as HTMLInputElement;

            if (input.value !== "") {
                input.parentElement.classList.add("input-focused");
            } else {
                input.parentElement.classList.remove("input-focused");
            }
        });

        this.btnDoCreateUser.onclick = async () => {
            this.btnDoCreateUser.disabled = true;
            this.btnDoCreateUser.textContent = "Loading...";
            await this.doCreateUser();
        };
    }

    async doCreateUser() {
        try {
            let data: ICreateUser = {
                name: this.inputUser.value,
                email: this.inputEmail.value,
                password: this.inputPassword.value,
                avatar: "",
                role: ""
            };

            const rawResponse = await fetch(`https://localhost:3333/signup`, {
                method: "POST",
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                    token: "teste",
                },
                body: JSON.stringify(data),
            });
            let response: LoginResponse = await rawResponse.json();

            if (response.success) {
                window.localStorage.setItem("GoBarber.Web:Token", response.token);
            }
        } catch (e) {
        } finally {
            this.btnDoCreateUser.disabled = false;
            this.btnDoCreateUser.textContent = "Register";
        }
    }
}
new SignUp();
