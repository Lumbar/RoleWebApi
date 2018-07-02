"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var material_1 = require("@angular/material");
var spanishRangeLabel = function (page, pageSize, length) {
    if (length == 0 || pageSize == 0) {
        return "0 de " + length;
    }
    length = Math.max(length, 0);
    var startIndex = page * pageSize;
    // If the start index exceeds the list length, do not try and fix the end index to the end.
    var endIndex = startIndex < length ?
        Math.min(startIndex + pageSize, length) :
        startIndex + pageSize;
    return startIndex + 1 + " - " + endIndex + " de " + length;
};
function getSpanishPaginatorIntl() {
    var paginatorIntl = new material_1.MatPaginatorIntl();
    paginatorIntl.itemsPerPageLabel = 'Opciones por página:';
    paginatorIntl.nextPageLabel = 'Siguiente';
    paginatorIntl.previousPageLabel = 'Atrás';
    paginatorIntl.getRangeLabel = spanishRangeLabel;
    return paginatorIntl;
}
exports.getSpanishPaginatorIntl = getSpanishPaginatorIntl;
//# sourceMappingURL=spanish-paginator-intl.js.map