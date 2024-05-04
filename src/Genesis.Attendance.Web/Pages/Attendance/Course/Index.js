$(function () {
    var l = abp.localization.getResource('Attendance');
    var createModal = new abp.ModalManager(abp.appPath + 'Attendance/Course/CreateModal');
    var editModal = new abp.ModalManager(abp.appPath + 'Attendance/Course/UpdateModal');

    var dataTable = $('#DataTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(genesis.attendance.attendance.department.getList),
            columnDefs: [
                {
                    title: l('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: l('Edit'),
                                    visible:
                                        abp.auth.isGranted('Attendance.Department.Edit'),
                                    action: function (data) {
                                        editModal.open({ id: data.record.id });
                                    }
                                },
                                {
                                    text: l('Delete'),
                                    visible:
                                        abp.auth.isGranted('Attendance.Department.Delete'),
                                    confirmMessage: function (data) {
                                        return l(
                                            'DeletionConfirmation',
                                            data.record.description
                                        );
                                    },
                                    action: function (data) {
                                        genesis.attendance.attendance.department.delete(data.record.id)
                                            .then(function () {
                                                abp.notify.success(l('SuccessfullyDeleted'));
                                                dataTable.ajax.reload();
                                            });
                                    }
                                }
                            ]
                    }
                },
                {
                    title: "Name",
                    data: "name"
                },
                {
                    title: "Short Name",
                    data: "shortName"
                },
                {
                    title: "Is Active",
                    data: "isActive"
                }
            ]
        })
    );

    createModal.onResult(function () {
        abp.notify.success(l('SuccessfullyCreated'));
        dataTable.ajax.reload();
    });

    editModal.onResult(function () {
        abp.notify.success(l('SuccessfullyUpdated'));
        dataTable.ajax.reload();
    });

    $('#CreateButton').click(function (e) {
        e.preventDefault();
        createModal.open();
    });
});
