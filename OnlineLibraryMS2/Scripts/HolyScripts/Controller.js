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