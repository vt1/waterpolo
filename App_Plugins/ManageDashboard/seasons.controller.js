angular.module("umbraco")
    .controller("SeasonsController", function ($scope, $route, notificationsService, $timeout, ManageDashboardService) {
        $scope.content = {tabs: [{ id: 1, label: "Create season" }, { id: 2, label: "Manage season" }]};
        $scope.promptIsVisible = false;
        $scope.showDeletePrompt = showDeletePrompt;
        $scope.hideDeletePrompt = hideDeletePrompt;
        $scope.confirmDelete = confirmDelete;
        $scope.createSeasonBtnState = "init";
        $scope.deleteSeasonBtnState = "init";
        $scope.updateSeasonBtnState = "init";
        $scope.newSeason = {};
        $scope.updateSeason = updateSeason;

        ManageDashboardService.getAllSeasons().then(function (seasons) {
            // convert to required format yyyy-mm-dd for filling input type date            
            seasons.forEach(function (season) {
                season.Season_Start_Date = new Date(season.Season_Start_Date).toISOString().split('T')[0];                
                season.Season_End_Date = new Date(season.Season_End_Date).toISOString().split('T')[0];
            });            
            $scope.seasons = seasons;
        });

        function showDeletePrompt() {
            $scope.promptIsVisible = true;            
        }

        function hideDeletePrompt() {
            $scope.promptIsVisible = false;
        }

        function confirmDelete(id) {
            hideDeletePrompt();
            $scope.deleteSeasonBtnState = "busy";
            ManageDashboardService.deleteSeason(id).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Delete season succesfully',
                        message: 'Delete season 200',
                        sticky: false,
                        type: 'success'
                    });                    
                } else {
                    notificationsService.add({
                        headline: 'Delete season failed',
                        message: res.status.toString(),
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.deleteSeasonBtnState = "init";
                $timeout(function () {
                    $route.reload();
                }, 1000);
            });
        }

        function updateSeason(season) {
            $scope.updateSeasonBtnState = "busy";
            ManageDashboardService.updateSeason(season).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Updated season succesfully',
                        message: 'Update season 200',
                        sticky: false,
                        type: 'success'
                    });                    
                } else {
                    notificationsService.add({
                        headline: 'Update season failed',
                        message: res.status.toString(),
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.updateSeasonBtnState = "init";
                $timeout(function () {
                    $route.reload();
                }, 1000);
            });
        }        

        $scope.addSeason = function () {
            $scope.createSeasonBtnState = "busy";
            ManageDashboardService.addSeason($scope.newSeason).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Create season succesfully',
                        message: 'Create season 200',
                        sticky: false,
                        type: 'success'
                    });
                    $timeout(function () {
                        $route.reload();
                    }, 1000);
                } else {
                    notificationsService.add({
                        headline: 'Create season error',
                        message: res.status.toString(),
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.createSeasonBtnState = "init";
            });            
        }
});