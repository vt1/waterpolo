angular.module("umbraco").factory('ManageDashboardService', function ($http) {
    return {
        getAllMembers: function () {
            return $http.get("/umbraco/backoffice/api/members/getallmembers/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        getRosterInMembersRelation: function () {
            return $http.get("/umbraco/backoffice/api/rosterinmembers/getrosterinmembersrelation/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        deleteRosterInMember: function (id) {            
            return $http.delete("/umbraco/backoffice/api/rosterinmembers/deleterosterinmember/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        addRosterInMember: function (rosterInMember) {
            return $http.post("/umbraco/backoffice/api/rosterinmembers/addrosterinmember/", rosterInMember).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllSeasons: function () {
            return $http.get("/umbraco/backoffice/api/seasons/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
            
        },
        getSeasonById: function (id) {
            return $http.get("/umbraco/backoffice/api/seasons/getbyid/" + id)
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        addSeason: function (season) {
            return $http.post("/umbraco/backoffice/api/seasons/addseason/", season).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        deleteSeason: function (id) {            
            return $http.delete("/umbraco/backoffice/api/seasons/deleteseason/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updateSeason: function (season) {
            return $http.post("/umbraco/backoffice/api/seasons/updateseason/", season).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        addGame: function (game) {
            return $http.post("/umbraco/backoffice/api/games/addgame/", game).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllGames: function () {
            return $http.get("/umbraco/backoffice/api/games/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        deleteGame: function (id) {            
            return $http.delete("/umbraco/backoffice/api/games/deletegame/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updateGame: function (game) {
            return $http.post("/umbraco/backoffice/api/games/updategame/", game).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        addEventType: function (eventType) {
            return $http.post("/umbraco/backoffice/api/events/addeventtype/", eventType).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllEvents: function () {
            return $http.get("/umbraco/backoffice/api/events/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        deleteEvent: function (id) {
            return $http.delete("/umbraco/backoffice/api/events/deleteevent/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updateEvent: function (event) {
            return $http.post("/umbraco/backoffice/api/events/updateevent/", event).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllSchedules: function () {
            return $http.get("/umbraco/backoffice/api/schedules/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        addSchedule: function (schedule) {
            return $http.post("/umbraco/backoffice/api/schedules/addschedule/", schedule).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        deleteSchedule: function (id) {
            return $http.delete("/umbraco/backoffice/api/schedules/deleteschedule/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updateSchedule: function (schedule) {
            return $http.post("/umbraco/backoffice/api/schedules/updateschedule/", schedule).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllRosters: function () {
            return $http.get("/umbraco/backoffice/api/rosters/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        addRoster: function (roster) {
            return $http.post("/umbraco/backoffice/api/rosters/addroster/", roster).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        deleteRoster: function (id) {
            return $http.delete("/umbraco/backoffice/api/rosters/deleteroster/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updateRoster: function (roster) {
            return $http.post("/umbraco/backoffice/api/rosters/updateroster/", roster).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllPaymentTypes: function () {
            return $http.get("/umbraco/backoffice/api/paymenttypes/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        deletePaymentType: function (id) {
            return $http.delete("/umbraco/backoffice/api/paymenttypes/deletepaymenttype/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updatePaymentType: function (paymentType) {
            return $http.post("/umbraco/backoffice/api/paymenttypes/updatepaymenttype/", paymentType).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        addPaymentType: function (paymentType) {
            return $http.post("/umbraco/backoffice/api/paymenttypes/addpaymenttype/", paymentType).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        addPayment: function (payment) {
            return $http.post("/umbraco/backoffice/api/payments/addpayment/", payment).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        getAllPayments: function () {
            return $http.get("/umbraco/backoffice/api/payments/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        deletePayment: function (id) {
            return $http.delete("/umbraco/backoffice/api/payments/deletepayment/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        updatePayment: function (payment) {
            return $http.post("/umbraco/backoffice/api/payments/updatepayment/", payment).then(
                function (successResponse) {
                    console.log(successResponse);
                    return successResponse;
                },
                function (errorResponse) {
                    console.log(errorResponse);
                    return errorResponse;
                });
        },
        
        uploadStats: function (file) {
            return $http({
                url: '/umbraco/backoffice/api/stats/upload/',
                method: 'POST',
                data: file,
                headers: { 'Content-Type': false },
                transformRequest: angular.identity 
            }).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                }
            );
        },
        deleteAllStatsByGameId: function (id) {
            return $http.delete("/umbraco/backoffice/api/stats/deleteallstatsbygameid/" + id).then(
                function (successResponse) {
                    return successResponse;
                },
                function (errorResponse) {
                    return errorResponse;
                });
        },
        getAllStats: function () {
            return $http.get("/umbraco/backoffice/api/stats/getall/")
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        },
        getStatsByGameId: function (id) {
            return $http.get("/umbraco/backoffice/api/stats/getstatsbygameid/" + id)
                .then(function (response) {
                    return response.data
                },
                    function (error) {
                        console.error(error);
                    }
                );
        }
    }
});

