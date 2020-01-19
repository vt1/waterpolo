angular.module("umbraco")
    .controller("StatsController", function ($scope, $routeParams, $route, notificationsService, $timeout, ManageDashboardService) {
        $scope.content = {
            tabs: [{ id: 1, label: "Upload CSV" },
            { id: 2, label: "Delete stats" },
            { id: 3, label: "Uploaded stats" }]
        };
        $scope.showStatsBtnState = "init";
        $scope.deleteStatsBtnState = "init";
        $scope.uploadStatsBtnState = "init";        

        ManageDashboardService.getAllGames().then(function (games) {
            $scope.games = games;
        });

        // control for uploading csv
        $scope.fileSelected = function (element) {
            var myFileSelected = element.files[0];
            $scope.file = myFileSelected;
        };

        // event for select game
        $scope.changed = function (gameId) {
            $scope.selectedGame = gameId;
        }

        $scope.uploadFile = function () {
            $scope.uploadStatsBtnState = "busy";
            var formData = new FormData();
            formData.append("gameId", $scope.selectedGame);
            formData.append('file', $scope.file);

            ManageDashboardService.uploadStats(formData).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Upload succesfully',
                        message: 'Upload 200',
                        sticky: false,
                        type: 'success'
                    });
                } else {
                    notificationsService.add({
                        headline: 'Upload failed',
                        message: res.data.Message,
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.uploadStatsBtnState = "init";
                $timeout(function () {
                    $route.reload();
                }, 1000);
            });
        }

        $scope.deleteAllStatsByGameId = function (selectedGame) {
            if (selectedGame !== undefined) {
                $scope.deleteStatsBtnState = "busy";
                ManageDashboardService.deleteAllStatsByGameId(selectedGame).then(function (res) {
                    if (res.status == 200) {
                        $scope.deleteStatsBtnState = "success";
                        notificationsService.add({
                            headline: 'Delete stats succesfully',
                            message: res.data + ' stats-rows deleted',
                            sticky: false,
                            type: 'success'
                        });
                    } else {
                        $scope.deleteStatsBtnState = "error";
                        notificationsService.add({
                            headline: 'Delete failed',
                            message: res.data.Message,
                            sticky: false,
                            type: 'error'
                        });
                    }
                    $timeout(function () {
                        $route.reload();
                    }, 1000);
                });
            }
        }

        $scope.getStatsByGameId = function (selectedGame) {
            if (selectedGame !== undefined) {
                
                $scope.showStatsBtnState = "busy";
                ManageDashboardService.getStatsByGameId(selectedGame).then(function (stats) {
                    $scope.stats = stats;
                    $scope.showStatsBtnState = "init";

                    $scope.hasStatsError = false;
                    for (var stat of stats) {
                        if (!stat.Player_Name || !stat.Stat_Type_Keyphrase)
                            $scope.hasStatsError = true;
                    }
                });                
            }            
        };
});