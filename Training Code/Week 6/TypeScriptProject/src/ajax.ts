export class Ajax {
    constructor() {

    }

    private xhr: XMLHttpRequest = new XMLHttpRequest();

    send(
        url: string,
        method: string = "get",
        success: (text: string) => void,
        fail: (text: string) => void = (error: string) => { console.log(error); }
    ): void {
        this.xhr = new XMLHttpRequest();
        this.xhr.addEventListener("load", () => {
            if (this.xhr.status === 200) {
                success(this.xhr.responseText);
            } else {
                fail(this.xhr.statusText);
            }
        });
        this.xhr.open(method, url);
        this.xhr.send();
        // this.xhr.send(objectForBody);
    }
}
