angular.module('Chat.controllers', [])
    .controller('ChatCtrl', function ($scope, $ionicModal, $timeout, _) {

    // With the new view caching in Ionic, Controllers are only called
    // when they are recreated or on app start, instead of every page change.
    // To listen for when this page is active (for example, to refresh data),
    // listen for the $ionicView.enter event:
    //$scope.$on('$ionicView.enter', function(e) {
    //});

    var vm = this;

    vm.showDetails = false;
    vm.toggleDetails = toggleDetails;

    function toggleDetails() {
        vm.showDetails = !vm.showDetails;

        var ammount = "0px";
        
        if(vm.showDetails) {
            ammount = "300px";   
        }

        document.documentElement.style.setProperty('--right-column-width', ammount);

        console.log(ammount);
    }
});