module.exports = class Webscraper {

    constructor(url) 
    {
        this.url = url;
    }

    display(){
        console.log(this.url);
    }
}