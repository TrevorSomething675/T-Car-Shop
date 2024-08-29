import { makeAutoObservable } from "mobx";

class CarStore {
    carsData:ApiItemsResponse<Car> = {} as ApiItemsResponse<Car>;
    constructor() {
        makeAutoObservable(this);
    }
    setCarsData(data:ApiItemsResponse<Car>){
        this.carsData = data;
    }
}

export default new CarStore;