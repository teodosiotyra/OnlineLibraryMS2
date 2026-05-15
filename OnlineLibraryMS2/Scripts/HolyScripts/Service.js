app.service("OnlineLibraryMSService", function ($http) {

    this.register = function (userData) {
        return $http({ method: "POST", url: "/Registration/RegisterUser", data: userData });
    };

    this.login = function (loginData) {
        return $http({ method: "POST", url: "/Registration/LoginUser", data: loginData });
    };

    this.regUserService2 = function (userInfo) {
        return $http({ method: "POST", url: "/Registration/RegUser2", data: userInfo });
    };

    this.getBooks = function () {
        return $http({ method: "GET", url: "/Books/GetBooks" });
    };

    this.getStats = function () {
        return $http({ method: "GET", url: "/Books/GetStats" });
    };

    this.addBook = function (book) {
        return $http({ method: "POST", url: "/Books/AddBook", data: book });
    };

    this.editBook = function (book) {
        return $http({ method: "POST", url: "/Books/EditBook", data: book });
    };

    this.deleteBook = function (id) {
        return $http({ method: "POST", url: "/Books/DeleteBook", data: { id: id } });
    };

    this.borrowBook = function (borrowData) {
        return $http({ method: "POST", url: "/Borrows/BorrowBook", data: borrowData });
    };

    this.returnBook = function (returnData) {
        return $http({ method: "POST", url: "/Borrows/ReturnBook", data: returnData });
    };

    this.getMyBorrows = function (userID) {
        return $http({ method: "GET", url: "/Borrows/GetMyBorrows?userID=" + userID });
    };
    this.getBorrowActivity = function () {
        return $http({ method: "GET", url: "/Borrows/GetBorrowActivity" });
    };

    this.getMonthlyActivity = function () {
        return $http({ method: "GET", url: "/Borrows/GetMonthlyActivity" });
    };

    this.getWeeklyActivity = function () {
        return $http({ method: "GET", url: "/Borrows/GetWeeklyActivity" });
    };

    this.getCategoryStats = function () {
        return $http({ method: "GET", url: "/Borrows/GetCategoryStats" });
    };

});