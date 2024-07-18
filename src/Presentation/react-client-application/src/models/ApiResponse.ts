  interface ApiResponse {
      data:{
        value: {
          items: Car[];
          count: number;
          pageCount: number;
        };
        statusCode: number;
        errorMessages: string[];
      }
    }