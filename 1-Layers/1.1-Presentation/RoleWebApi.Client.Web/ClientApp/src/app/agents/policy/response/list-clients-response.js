"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var base_response_1 = require("../../core/base-response");
var dtos_1 = require("../../../models/dtos");
var ListClientsResponse = /** @class */ (function (_super) {
    __extends(ListClientsResponse, _super);
    function ListClientsResponse() {
        var _this = _super.call(this) || this;
        _this.Clients = new dtos_1.ClientPagedList();
        return _this;
    }
    return ListClientsResponse;
}(base_response_1.BaseResponse));
exports.ListClientsResponse = ListClientsResponse;
//# sourceMappingURL=list-clients-response.js.map