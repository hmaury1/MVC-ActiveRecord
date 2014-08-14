Ext.define('MyApp.model.UserModel', {
    extend: 'Ext.data.Model',
    idProperty: 'Id',
    fields: [
        { name: 'Id', type: 'int' },
        { name: 'Name', type: 'string' },
        { name: 'Email', type: 'string' },
        { name: 'Password', type: 'string' }
    ]
});