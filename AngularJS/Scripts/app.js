var domain = "http://" + location.host;
var app = angular.module("CompanyApplication", []);
app.controller("companyController", ['$http', function($http) {
    var self = this;
    self.employees = [];
    self.failReaons = "";
    self.filterJob = "";
    $http.post(domain + "/Home/GetEmployees?count=20").then(function(response) {
            self.employees = response.data;
        },
        function (reason, status, headers, config) {
            self.employees = null;
            self.failReaons = reason;
        });
    self.refreshData = function() {
        $http.post(domain + "/Home/GetEmployees?count=20").then(function(response) {
                self.employees = response.data;
            },
            function(reason) {
                self.employees = null;
                self.failReaons = reason;
            });
    };
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
app.controller("tabController", function() {
    var self = this;
    self.currentTab = "add";
    self.isCurrentTab = function(isTab) {
        return self.currentTab == isTab;
    };
});
app.controller("addEmployeeController",["$http", function ($http) {
    var self = this;
    self.submitEmployee = {};
    self.isSubmitted = false;
    self.submitForm = function (controller, isValid) {
        if (isValid == false) {
            self.isSubmitted = true;
            return;
        }
        $http.post(domain + "/Home/AddEmployee", { JSONemployee: JSON.stringify(self.submitEmployee) }).then(function() {
            self.submitEmployee = {};
            controller.refreshData();
        }, function() {
            controller.employees = null;
        });
    };
}]);