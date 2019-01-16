export class Photo {
    id: string;
    owner: string;
    secret: string;
    server: string;
    farm: number;
    title: string;
    url:string;
    ispublic: number;
    isfriend: number;
    isfamily: number;

    toUrl(){
        return this.url;
    }
}

export class Photos {
    page: number;
    pages: string;
    perpage: number;
    total: string;
    photo: Photo[];
}

export class RootObject {
    photos: Photos;
    stat: string;
}




