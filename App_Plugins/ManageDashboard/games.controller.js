angular.module("umbraco")
    .controller("GamesController", function ($scope, $timeout, $route, notificationsService, ManageDashboardService) {        
        $scope.content = {tabs: [{ id: 1, label: "Create" }, { id: 2, label: "Manage" }]};
        $scope.newGame = {};
        $scope.createGame = createGame;
        $scope.promptIsVisible = false;
        $scope.showDeletePrompt = showDeletePrompt;
        $scope.hideDeletePrompt = hideDeletePrompt;
        $scope.confirmDelete = confirmDelete;
        $scope.updateGame = updateGame;
        $scope.createGameBtnState = "init";
        $scope.deleteGameBtnState = "init";
        $scope.updateGameBtnState = "init";

        ManageDashboardService.getAllSeasons().then(function (seasons) {
            $scope.seasons = seasons;
        });

        ManageDashboardService.getAllGames().then(function (games) {
            games.forEach(function (game) {
                game.Game_Date = new Date(game.Game_Date).toISOString().split('T')[0];
            });
            $scope.games = games;
        });

        function showDeletePrompt() {
            $scope.promptIsVisible = true;
        }

        function hideDeletePrompt() {
            $scope.promptIsVisible = false;
        }

        function confirmDelete(id) {
            hideDeletePrompt();
            $scope.deleteGameBtnState = "busy";
            ManageDashboardService.deleteGame(id).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Delete game succesfully',
                        message: 'Delete game 200',
                        sticky: false,
                        type: 'success'
                    });                    
                } else {
                    notificationsService.add({
                        headline: 'Delete game failed',
                        message: res.status.toString(),
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.deleteGameBtnState = "init";
                $timeout(function () {
                    $route.reload();
                }, 1000);
            });
        }

        function createGame(newGame) {
            $scope.createGameBtnState = "busy";
            ManageDashboardService.addGame(newGame).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Create game succesfully',
                        message: 'Create game 200',
                        sticky: false,
                        type: 'success'
                    });
                    $timeout(function () {
                        $route.reload();
                    }, 1000);
                } else {
                    notificationsService.add({
                        headline: 'Create game failed',
                        message: res.status.toString() + res.data,
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.createGameBtnState = "init";
            });
        }

        function updateGame(game) {
            $scope.updateGameBtnState = "busy";
            ManageDashboardService.updateGame(game).then(function (res) {
                if (res.status == 200) {
                    notificationsService.add({
                        headline: 'Updated game succesfully',
                        message: 'Update game 200',
                        sticky: false,
                        type: 'success'
                    });
                } else {
                    notificationsService.add({
                        headline: 'Update game failed',
                        message: res.status.toString(),
                        sticky: false,
                        type: 'error'
                    });
                }
                $scope.updateGameBtnState = "init";
                $timeout(function () {
                    $route.reload();
                }, 1000);
            });
        }
});