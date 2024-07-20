interface GetCarsFilterModel{
    imagesFillingType: ImagesFillingTypeEnum
    
}

enum ImagesFillingTypeEnum {
    'WithAllImages' = 0,
    'WithFirstImage' = 1,
    'WithoutImages' = 2
}