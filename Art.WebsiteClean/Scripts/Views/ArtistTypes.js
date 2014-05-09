/// <reference path="_references.views.js" />
/// <reference path="../webExpress/webExpress.controls.adpaters.js" />

(function () {
    window.art.ui.view.ArtistTypes = ArtistTypesClass;

    function ArtistTypesClass() {
        var self = this;
        window.art.ui.view.ViewBase.call(self);
        function init() {
            self.saveType = saveType;
            self.remove = remove;
            self.refresh = refresh;
        }

        function saveType(artType, onSuccess) {
            var url = artType.Id > 0 ? "/Artist/UpdateProfession" : "/Artist/AddProfession";
            webExpress.utility.ajax.request(url, artType, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function remove(professionId, onSuccess) {
            var url = "/Artist/DeleteProfession/" + professionId;
            webExpress.utility.ajax.request(url, professionId, function (data) {
                if (data.IsSuccess) {
                    if (onSuccess) {
                        onSuccess();
                    }
                    refresh();
                } else {
                    alert(data.Message);
                }
            });
        }

        function refresh() {
            var url = "/Artist/ProfessionList";
            webExpress.utility.ajax.request(url, null, function (data) {
                $(".data").html(data);
            });
        }
        init();
    }
})();