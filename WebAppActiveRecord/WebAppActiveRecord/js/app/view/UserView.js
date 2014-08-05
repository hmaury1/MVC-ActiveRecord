Ext.define('MyApp.view.UserView', {
    extend: 'Ext.grid.Panel',
    title: 'Users',
    alias: 'widget.user',
    store: 'UserStore',
    flex: 1,
    layout:{
        type:'fit'
    },
    renderTo: 'panelExtjs',
    columns: [
        { text: 'ID', dataIndex: 'Id' },
        { text: 'Name', dataIndex: 'Name' },
        { text: 'Email', dataIndex: 'Email', flex: 1 },
        { text: 'Password', dataIndex: 'Password', flex: 1 }
    ],
    dockedItems: [{
        xtype: 'toolbar',
        dock: 'top',
        items: [{
            text: 'New',
            action: 'new'
        }]
    }]
    
});