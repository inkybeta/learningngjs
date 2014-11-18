var filters = angular.module("filters", []);
filters.filter("objectProperty", function() {
    return function (items, object) {
        if (object.Value == "") {
            return items;
        }
        var filtered = [];
        var Property = object.Property;
        var Value = object.Value;
        for (var i = 0; i < items.length; i++) {
            if (items[i][Property].toString().indexOf(Value) != -1) {
                filtered.push(items[i]);
            }
        }
        return filtered;
    };
});