function HomePageCtrl($scope, $http) {
    $scope.ApiUrl = '/Events';
    $scope.events = [];
      
    $scope.loadevents = function() {
        $http.get($scope.ApiUrl).success(function(data) {
            $scope.events = data;
            $scope.location = data[0].Address;
        }).error(function(response) {
                    
        });
    };
    $scope.loadevents();            
};