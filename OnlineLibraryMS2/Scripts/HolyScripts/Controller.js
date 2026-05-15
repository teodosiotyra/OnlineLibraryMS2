var app = angular.module("OnlineLibraryMS", []);

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

});

app.controller("OnlineLibraryMSController", function ($scope, OnlineLibraryMSService) {

    $scope.regUser2 = function () {
        var userData = {
            Username: $scope.regUsername,
            Password: $scope.regPassword,
            FullName: $scope.regName
        };
        OnlineLibraryMSService.regUserService2(userData).then(function (response) {
            if (response.data.success) {
                alert("Registered Successfully");
                window.location.href = "/Registration/Login";
            } else {
                alert(response.data.message);
            }
        });
    };

    $scope.checkLogin = function () {
        var loginData = {
            Username: $scope.loginUsername,
            Password: $scope.loginPassword
        };
        OnlineLibraryMSService.login(loginData).then(function (response) {
            if (response.data.status == "Success") {
                // Save UserID and Role to localStorage
                localStorage.setItem("UserID", response.data.UserID);
                localStorage.setItem("Role", response.data.role);
                localStorage.setItem("FullName", response.data.fullName);

                if (response.data.role == "Admin") {
                    window.location.href = "/Registration/AdminDashboard";
                } else {
                    window.location.href = "/Registration/Dashboard";
                }
            } else {
                alert(response.data.message || "Invalid Username or Password");
            }
        });
    };

    $scope.clearFields = function () {
        $scope.regUsername = "";
        $scope.regPassword = "";
        $scope.regName = "";
    };

    $scope.clearLogin = function () {
        $scope.loginUsername = "";
        $scope.loginPassword = "";
    };

});