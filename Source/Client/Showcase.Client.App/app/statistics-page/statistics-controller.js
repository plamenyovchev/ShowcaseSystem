﻿(function () {
    'use strict';

    var statisticsController = function statisticsController(statisticsData) {
        var vm = this;
       
        statisticsData.getMainStatistics()
            .then(function (statistics) {
                vm.mainStatistics = statistics;
            });

        statisticsData.getProjectsForLastSixMonths()
            .then(function (projects) {
                vm.projectsByMonth = projects;
            });

        statisticsData.getProjectsCountTag()
            .then(function (projectsByTag) {
                vm.projectsByTag = projectsByTag;
            });

        statisticsData.getMostLikedProjects()
            .then(function (mostLiked) {
                vm.mostLiked = mostLiked;
            });

        statisticsData.getTopUsers()
            .then(function(topUsers) {
                vm.topUsers = topUsers;
            });
    };

    angular
        .module('showcaseSystem.controllers')
        .controller('statisticsController', ['statisticsData', statisticsController]);
}());