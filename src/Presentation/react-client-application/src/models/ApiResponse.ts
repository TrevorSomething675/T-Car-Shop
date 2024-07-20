interface ApiResponse {
       value: {
         items: Car[];
         count: number;
         pageCount: number;
       };
      statusCode: number;
      errorMessages: string[];
  }