$(document).ready(function () {
    alert("Working");

    GetState();
    GetNationality();
    GetCategory();
    GetGender();
    GetReligion();

    $('#PerDistrict').attr('disabled', true);
    $('#PerBlock').attr('disabled', true);
    $('#PerVillage').attr('disabled', true);

    $('#PreDistrict').attr('disabled', true);
    $('#PreBlock').attr('disabled', true);
    $('#PreVillage').attr('disabled', true);

    $('#PerState').change(function () {
        $('#PerDistrict').attr('disabled', false);

        var id = $(this).val();
        //$('#PerDistrict').empty();
        //$('#PerDistrict').append('<Option>-----Select District-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/District?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PerDistrict').append('<option value=' + data.districtCode + '>' + data.districtName + '</option>')
                })
            }

        })

    });

    $('#PreState').change(function () {
        $('#PreDistrict').attr('disabled', false);

        var id = $(this).val();
        //$('#PreDistrict').empty();
        //$('#PreDistrict').append('<Option>-----Select District-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/District?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PreDistrict').append('<option value=' + data.districtCode + '>' + data.districtName + '</option>')
                })
            }

        })

    });


    $('#PerDistrict').change(function () {
        $('#PerBlock').attr('disabled', false);
        var id = $(this).val();
        //$('#PerBlock').empty();
        //$('#PerBlock').append('<Option>-----Select Block-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/Block?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PerBlock').append('<option value=' + data.blockCode + '>' + data.blockName + '</option>')
                })
            }

        })

    });
    $('#PreDistrict').change(function () {
        $('#PreBlock').attr('disabled', false);
        var id = $(this).val();
        //$('#PreBlock').empty();
        //$('#PreBlock').append('<Option>-----Select Block-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/Block?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PreBlock').append('<option value=' + data.blockCode + '>' + data.blockName + '</option>')
                })
            }

        })

    });


    $('#PerBlock').change(function () {
        $('#PerVillage').attr('disabled', false);
        var id = $(this).val();
        //$('#PerVillage').empty();
        //$('#PerVillage').append('<Option>-----Select Village-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/Village?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PerVillage').append('<option value=' + data.villageCode + '>' + data.villageName + '</option>')
                })

            }

        })

    });

    $('#PreBlock').change(function () {
        $('#PreVillage').attr('disabled', false);
        var id = $(this).val();
        //$('#PreVillage').empty();
        //$('#PreVillage').append('<Option>-----Select Village-----<Option/>');
        $.ajax({
            url: '/ApplicantMbbs/Village?id=' + id,
            success: function (result) {
                $.each(result, function (i, data) {
                    $('#PreVillage').append('<option value=' + data.villageCode + '>' + data.villageName + '</option>')
                })

            }

        })

    });


});

function GetState() {
    $.ajax({
        url: '/ApplicantMbbs/State',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#PerState').append('<option value=' + data.stateCode + '>' + data.stateName + '</option>')
                $('#PreState').append('<option value=' + data.stateCode + '>' + data.stateName + '</option>')
            });
        }
    });
}

function GetNationality() {
    $.ajax({
        url: '/ApplicantMbbs/Nationality',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Nationality').append('<option value=' + data.nationality + '>' + data.nationalityName + '</option>')

            });
        }
    });
}

function GetCategory() {
    $.ajax({
        url: '/ApplicantMbbs/Category',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Category').append('<option value=' + data.category + '>' + data.categoryDesc + '</option>')

            });
        }
    });
}

function GetGender() {
    $.ajax({
        url: '/ApplicantMbbs/Gender',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Gender').append('<option value=' + data.gender + '>' + data.genderDesc + '</option>')

            });
        }
    });
}



function GetReligion() {
    $.ajax({
        url: '/ApplicantMbbs/Religion',
        success: function (result) {
            $.each(result, function (i, data) {
                $('#Religion').append('<option value=' + data.religion + '>' + data.religionDesc + '</option>')

            });
        }
    });
}

function autoFillAddress() {

    let checkBox = document.getElementById('checkBox');

    let PerState = document.getElementById('PerState');
    let PerDistrict = document.getElementById('PerDistrict');
    let PerBlock = document.getElementById('PerBlock');
    let PerVillage = document.getElementById('PerVillage');
    let PermanentAddress = document.getElementById('PermanentAddress');

    let PreState = document.getElementById('PreState');
    let PreDistrict = document.getElementById('PreDistrict');
    let PreBlock = document.getElementById('PreBlock');
    let PreVillage = document.getElementById('PreVillage');
    let PresentAddress = document.getElementById('PresentAddress');

    if (checkBox.checked == true) {

        //$('#PreDistrict').attr('disabled', false);
        //$('#PreBlock').attr('disabled', false);
        //$('#PreVillage').attr('disabled', false);

        let PerStateVal = PerState.value;
        let PerDistrictVal = PerDistrict.value;
        let PerBlockVal = PerBlock.value;
        let PerVillageVal = PerVillage.value;
        let PermanentAddressVal = PermanentAddress.value;

        PreState.value = PerStateVal;

        PreDistrict.value = PerDistrictVal;
        PreBlock.value = PerBlockVal;
        PreVillage.value = PerVillageVal;
        PresentAddress.value = PermanentAddressVal;
    } else {
        //$('#PreDistrict').attr('disabled', true);
        //$('#PreBlock').attr('disabled', true);
        //$('#PreVillage').attr('disabled', true);
    }
}
function category() {

    let category = document.getElementById('Category');
    if (category.value == 4) {
        $('#CategoryCertificate').attr('disabled', true);

    }
    else {
        $('#CategoryCertificate').attr('disabled', false);
    }
}