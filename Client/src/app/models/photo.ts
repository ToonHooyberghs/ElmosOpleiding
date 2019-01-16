export default class Photo {
    /**
     *
     */
    constructor(public title:string, public url:string) {
        

        
    }

    toUrl(){
        return this.url;
    }
}
