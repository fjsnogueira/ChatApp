(function () {
    'use strict';

    angular.module('app')
        .config(defineRoutes);

    defineRoutes.$inject = ["$stateProvider", "$urlRouterProvider"];

    function defineRoutes ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('app', {
                url: '/app',
                abstract: false,
                templateUrl: 'chat/chat.layout.html',
                controller: 'AppCtrl'
            })
            
            // .state('app.menu', {
            //     url: '/menu',
            //     views: {
            //         'menuContent': {
            //         templateUrl: 'chat/chat.menu.html',
            //         controller: 'ChatCtrl'
            //         }
            //     }
            //     })
            
            ;
        // if none of the above states are matched, use this as the fallback
        $urlRouterProvider.otherwise('/app');
    }
})();