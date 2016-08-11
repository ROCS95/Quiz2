// objteto tipo Resource
var Resource = function (resource) {
    this.resource = resource;
    this.getAll = function () {
        return $.ajax({ url: 'http://localhost:51942/api/' + this.resource });
    };
    this.create = function (ItemDTO) {
        return $.ajax({
            type: "POST",
            url: 'http://localhost:51942/api/' + this.resource,
            data: ItemDTO
        });
    };
    this.delete = function (id) {
        return $.ajax({
            type: "DELETE",
            url: 'http://localhost:51942/api/' + this.resource + '/' + id
        });
    };
};

//creamos uno por cada entidad de objeto creado arriba que recibe el nombre de la entidad
var Pokemon = new Resource('Item');
