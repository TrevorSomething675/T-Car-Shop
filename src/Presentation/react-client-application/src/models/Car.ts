interface Car {
    id: string;
    name: string;
    shortDescription: string;
    isVisible: boolean;
    users: string[];
    images: Image[];
    manufacturerId: string;
    manufacturer: any;
    price: number;
    oldPrice: number;
    description: Description;
    currencyType: number;
    offers: Offers;
  }