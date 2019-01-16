import Photo from './photo';

export class FlickerPhoto extends Photo {
    id: string;
    owner: string;
    secret: string;
    server: string;
    farm: number;   
    ispublic: number;
    isfriend: number;
    isfamily: number;

    constructor(public title:string, public url:string) {
         
        super(title,url);
        
    }

    toUrl(){
        return this.url;
    }
}

export class FlickerPhotos {
    page: number;
    pages: string;
    perpage: number;
    total: string;
    photo: FlickerPhoto[];
}

export class RootObject {
    photos: FlickerPhotos;
    stat: string;
}




