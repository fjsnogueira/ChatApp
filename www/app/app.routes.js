(function () {
    'use strict';

    angular.module('ChatApp')
        .config(defineRoutes);

    defineRoutes.$inject = ["$stateProvider", "$urlRouterProvider"];

    function defineRoutes ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('chat', {
                url: '/chat',
                abstract: false,
                templateUrl: 'chat/chat.layout.html',
                controller: 'ChatCtrl'
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
        $urlRouterProvider.otherwise('/chat');
    }
})();