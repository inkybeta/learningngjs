var app = angular.module("CompanyApplication", []);
app.controller("companyController", ['$http', '$scope', function ($http, $scope) {
    $scope.employees = [];
    $scope.failReaons = "";
    $scope.filterJob = "";
    $http.post("Home/GetEmployees?count=20").success(function(data) {
        $scope.employees = JSON.parse(data);
    }).error(function(reason) {
        $scope.employees = null;
        $scope.failReaons = reason;
    });

    /*$scope.$watch("filterJob", function(newValue, oldValue) {
        if (newValue == oldValue) {
            return;
        }
        if (newValue == "" && oldValue != "") {
            $http.post("GetEmployees").success(function(data) {
                $scope.employees = JSON.parse(data);
            }).fail(function(reason) {
                $scope.employees = null;
                $scope.failReaons = reason;
            });
            return;
        }
        if (newValue != "") {
            $http.post("GetEmployeesByJob").success(function(data) {
                $scope.employees = JSON.parse(data);
            }).fail(function() {

            });
        }
    });*/
}]);