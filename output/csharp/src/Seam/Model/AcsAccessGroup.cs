using System.Runtime.Serialization;
using System.Text;
using JsonSubTypes;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Seam.Model;

namespace Seam.Model
{
[DataContract(Name = "seamModel_acsAccessGroup_model")]
public class AcsAccessGroup
{
[JsonConstructorAttribute]
protected AcsAccessGroup() { }

public AcsAccessGroup(AcsAccessGroup.AccessGroupTypeEnum? accessGroupType = default, string? accessGroupTypeDisplayName = default, AcsAccessGroupAccessSchedule? accessSchedule = default, string? acsAccessGroupId = default, string? acsSystemId = default, string? connectedAccountId = default, string? createdAt = default, string? displayName = default, List<AcsAccessGroupErrors>? errors = default, AcsAccessGroup.ExternalTypeEnum? externalType = default, string? externalTypeDisplayName = default, bool? isManaged = default, string? name = default, List<AcsAccessGroupPendingMutations>? pendingMutations = default, List<AcsAccessGroupWarnings>? warnings = default, string? workspaceId = default)
{
AccessGroupType = accessGroupType;
AccessGroupTypeDisplayName = accessGroupTypeDisplayName;
AccessSchedule = accessSchedule;
AcsAccessGroupId = acsAccessGroupId;
AcsSystemId = acsSystemId;
ConnectedAccountId = connectedAccountId;
CreatedAt = createdAt;
DisplayName = displayName;
Errors = errors;
ExternalType = externalType;
ExternalTypeDisplayName = externalTypeDisplayName;
IsManaged = isManaged;
Name = name;
PendingMutations = pendingMutations;
Warnings = warnings;
WorkspaceId = workspaceId;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum AccessGroupTypeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "pti_unit")]
PtiUnit = 1,

[EnumMember(Value = "pti_access_level")]
PtiAccessLevel = 2,

[EnumMember(Value = "salto_ks_access_group")]
SaltoKsAccessGroup = 3,

[EnumMember(Value = "brivo_group")]
BrivoGroup = 4,

[EnumMember(Value = "salto_space_group")]
SaltoSpaceGroup = 5,

[EnumMember(Value = "dormakaba_community_access_group")]
DormakabaCommunityAccessGroup = 6,

[EnumMember(Value = "dormakaba_ambiance_access_group")]
DormakabaAmbianceAccessGroup = 7,

[EnumMember(Value = "avigilon_alta_group")]
AvigilonAltaGroup = 8,

[EnumMember(Value = "kisi_access_group")]
KisiAccessGroup = 9,
}

[JsonConverter(typeof(JsonSubtypes), "error_code")]
[JsonSubtypes.FallBackSubType(typeof(AcsAccessGroupErrorsUnrecognized))]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupErrorsFailedToCreateOnAcsSystem), "failed_to_create_on_acs_system")]
public abstract class AcsAccessGroupErrors
{
public abstract string ErrorCode { get; }

public abstract override string ToString();
}

[DataContract(Name = "seamModel_acsAccessGroupErrorsFailedToCreateOnAcsSystem_model")]
public class AcsAccessGroupErrorsFailedToCreateOnAcsSystem : AcsAccessGroupErrors
{
[JsonConstructorAttribute]
protected AcsAccessGroupErrorsFailedToCreateOnAcsSystem() { }

public AcsAccessGroupErrorsFailedToCreateOnAcsSystem(string? createdAt = default, string errorCode = default, string? message = default)
{
CreatedAt = createdAt;
ErrorCode = errorCode;
Message = message;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
public override string ErrorCode { get; } = "failed_to_create_on_acs_system";

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupErrorsUnrecognized_model")]
public class AcsAccessGroupErrorsUnrecognized : AcsAccessGroupErrors
{
[JsonConstructorAttribute]
protected AcsAccessGroupErrorsUnrecognized() { }

public AcsAccessGroupErrorsUnrecognized(string errorCode = default)
{
ErrorCode = errorCode;
}

[DataMember(Name = "error_code", IsRequired = true, EmitDefaultValue = false)]
public override string ErrorCode { get; } = "unrecognized";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum ExternalTypeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "pti_unit")]
PtiUnit = 1,

[EnumMember(Value = "pti_access_level")]
PtiAccessLevel = 2,

[EnumMember(Value = "salto_ks_access_group")]
SaltoKsAccessGroup = 3,

[EnumMember(Value = "brivo_group")]
BrivoGroup = 4,

[EnumMember(Value = "salto_space_group")]
SaltoSpaceGroup = 5,

[EnumMember(Value = "dormakaba_community_access_group")]
DormakabaCommunityAccessGroup = 6,

[EnumMember(Value = "dormakaba_ambiance_access_group")]
DormakabaAmbianceAccessGroup = 7,

[EnumMember(Value = "avigilon_alta_group")]
AvigilonAltaGroup = 8,

[EnumMember(Value = "kisi_access_group")]
KisiAccessGroup = 9,
}

[JsonConverter(typeof(JsonSubtypes), "mutation_code")]
[JsonSubtypes.FallBackSubType(typeof(AcsAccessGroupPendingMutationsUnrecognized))]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate), "deferring_user_membership_update")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsUpdatingEntranceMembership), "updating_entrance_membership")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsUpdatingUserMembership), "updating_user_membership")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsUpdatingAccessSchedule), "updating_access_schedule")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsUpdatingGroupInformation), "updating_group_information")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsDeferringDeletion), "deferring_deletion")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsDeleting), "deleting")]
[JsonSubtypes.KnownSubType(typeof(AcsAccessGroupPendingMutationsCreating), "creating")]
public abstract class AcsAccessGroupPendingMutations
{
public abstract string MutationCode { get; }

public abstract override string ToString();
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsCreating_model")]
public class AcsAccessGroupPendingMutationsCreating : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsCreating() { }

public AcsAccessGroupPendingMutationsCreating(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "creating";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsDeleting_model")]
public class AcsAccessGroupPendingMutationsDeleting : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsDeleting() { }

public AcsAccessGroupPendingMutationsDeleting(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deleting";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsDeferringDeletion_model")]
public class AcsAccessGroupPendingMutationsDeferringDeletion : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsDeferringDeletion() { }

public AcsAccessGroupPendingMutationsDeferringDeletion(string? createdAt = default, string? message = default, string mutationCode = default)
{
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deferring_deletion";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformation_model")]
public class AcsAccessGroupPendingMutationsUpdatingGroupInformation : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingGroupInformation() { }

public AcsAccessGroupPendingMutationsUpdatingGroupInformation(string? createdAt = default, AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom? from = default, string? message = default, string mutationCode = default, AcsAccessGroupPendingMutationsUpdatingGroupInformationTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_group_information";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingGroupInformationTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformationFrom_model")]
public class AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom() { }

public AcsAccessGroupPendingMutationsUpdatingGroupInformationFrom(string? name = default)
{
Name = name;
}

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingGroupInformationTo_model")]
public class AcsAccessGroupPendingMutationsUpdatingGroupInformationTo
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingGroupInformationTo() { }

public AcsAccessGroupPendingMutationsUpdatingGroupInformationTo(string? name = default)
{
Name = name;
}

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessSchedule_model")]
public class AcsAccessGroupPendingMutationsUpdatingAccessSchedule : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingAccessSchedule() { }

public AcsAccessGroupPendingMutationsUpdatingAccessSchedule(string? createdAt = default, AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom? from = default, string? message = default, string mutationCode = default, AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_access_schedule";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessScheduleFrom_model")]
public class AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom() { }

public AcsAccessGroupPendingMutationsUpdatingAccessScheduleFrom(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingAccessScheduleTo_model")]
public class AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo() { }

public AcsAccessGroupPendingMutationsUpdatingAccessScheduleTo(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembership_model")]
public class AcsAccessGroupPendingMutationsUpdatingUserMembership : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingUserMembership() { }

public AcsAccessGroupPendingMutationsUpdatingUserMembership(string? createdAt = default, AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom? from = default, string? message = default, string mutationCode = default, AcsAccessGroupPendingMutationsUpdatingUserMembershipTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_user_membership";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingUserMembershipTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembershipFrom_model")]
public class AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom() { }

public AcsAccessGroupPendingMutationsUpdatingUserMembershipFrom(string? acsUserId = default)
{
AcsUserId = acsUserId;
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingUserMembershipTo_model")]
public class AcsAccessGroupPendingMutationsUpdatingUserMembershipTo
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingUserMembershipTo() { }

public AcsAccessGroupPendingMutationsUpdatingUserMembershipTo(string? acsUserId = default)
{
AcsUserId = acsUserId;
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembership_model")]
public class AcsAccessGroupPendingMutationsUpdatingEntranceMembership : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingEntranceMembership() { }

public AcsAccessGroupPendingMutationsUpdatingEntranceMembership(string? createdAt = default, AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom? from = default, string? message = default, string mutationCode = default, AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo? to = default)
{
CreatedAt = createdAt;
From = from;
Message = message;
MutationCode = mutationCode;
To = to;
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "from", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom? From { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "updating_entrance_membership";

[DataMember(Name = "to", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo? To { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom_model")]
public class AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom() { }

public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipFrom(string? acsEntranceId = default)
{
AcsEntranceId = acsEntranceId;
}

[DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsEntranceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUpdatingEntranceMembershipTo_model")]
public class AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo() { }

public AcsAccessGroupPendingMutationsUpdatingEntranceMembershipTo(string? acsEntranceId = default)
{
AcsEntranceId = acsEntranceId;
}

[DataMember(Name = "acs_entrance_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsEntranceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsDeferringUserMembershipUpdate_model")]
public class AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate() { }

public AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate(string? acsUserId = default, string? createdAt = default, string? message = default, string mutationCode = default, AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum? variant = default)
{
AcsUserId = acsUserId;
CreatedAt = createdAt;
Message = message;
MutationCode = mutationCode;
Variant = variant;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum VariantEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "adding")]
Adding = 1,

[EnumMember(Value = "removing")]
Removing = 2,
}

[DataMember(Name = "acs_user_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsUserId { get; set; }

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "deferring_user_membership_update";

[DataMember(Name = "variant", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupPendingMutationsDeferringUserMembershipUpdate.VariantEnum? Variant { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupPendingMutationsUnrecognized_model")]
public class AcsAccessGroupPendingMutationsUnrecognized : AcsAccessGroupPendingMutations
{
[JsonConstructorAttribute]
protected AcsAccessGroupPendingMutationsUnrecognized() { }

public AcsAccessGroupPendingMutationsUnrecognized(string mutationCode = default)
{
MutationCode = mutationCode;
}

[DataMember(Name = "mutation_code", IsRequired = true, EmitDefaultValue = false)]
public override string MutationCode { get; } = "unrecognized";

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataMember(Name = "access_group_type", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroup.AccessGroupTypeEnum? AccessGroupType { get; set; }

[DataMember(Name = "access_group_type_display_name", IsRequired = false, EmitDefaultValue = false)]
public string? AccessGroupTypeDisplayName { get; set; }

[DataMember(Name = "access_schedule", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupAccessSchedule? AccessSchedule { get; set; }

[DataMember(Name = "acs_access_group_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsAccessGroupId { get; set; }

[DataMember(Name = "acs_system_id", IsRequired = false, EmitDefaultValue = false)]
public string? AcsSystemId { get; set; }

[DataMember(Name = "connected_account_id", IsRequired = false, EmitDefaultValue = false)]
public string? ConnectedAccountId { get; set; }

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "display_name", IsRequired = false, EmitDefaultValue = false)]
public string? DisplayName { get; set; }

[DataMember(Name = "errors", IsRequired = false, EmitDefaultValue = false)]
public List<AcsAccessGroupErrors>? Errors { get; set; }

[DataMember(Name = "external_type", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroup.ExternalTypeEnum? ExternalType { get; set; }

[DataMember(Name = "external_type_display_name", IsRequired = false, EmitDefaultValue = false)]
public string? ExternalTypeDisplayName { get; set; }

[DataMember(Name = "is_managed", IsRequired = false, EmitDefaultValue = false)]
public bool? IsManaged { get; set; }

[DataMember(Name = "name", IsRequired = false, EmitDefaultValue = false)]
public string? Name { get; set; }

[DataMember(Name = "pending_mutations", IsRequired = false, EmitDefaultValue = false)]
public List<AcsAccessGroupPendingMutations>? PendingMutations { get; set; }

[DataMember(Name = "warnings", IsRequired = false, EmitDefaultValue = false)]
public List<AcsAccessGroupWarnings>? Warnings { get; set; }

[DataMember(Name = "workspace_id", IsRequired = false, EmitDefaultValue = false)]
public string? WorkspaceId { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupAccessSchedule_model")]
public class AcsAccessGroupAccessSchedule
{
[JsonConstructorAttribute]
protected AcsAccessGroupAccessSchedule() { }

public AcsAccessGroupAccessSchedule(string? endsAt = default, string? startsAt = default)
{
EndsAt = endsAt;
StartsAt = startsAt;
}

[DataMember(Name = "ends_at", IsRequired = false, EmitDefaultValue = false)]
public string? EndsAt { get; set; }

[DataMember(Name = "starts_at", IsRequired = false, EmitDefaultValue = false)]
public string? StartsAt { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

[DataContract(Name = "seamModel_acsAccessGroupWarnings_model")]
public class AcsAccessGroupWarnings
{
[JsonConstructorAttribute]
protected AcsAccessGroupWarnings() { }

public AcsAccessGroupWarnings(string? createdAt = default, string? message = default, AcsAccessGroupWarnings.WarningCodeEnum? warningCode = default)
{
CreatedAt = createdAt;
Message = message;
WarningCode = warningCode;
}

[JsonConverter(typeof(SafeStringEnumConverter))]
public enum WarningCodeEnum
{
[EnumMember(Value = "unrecognized")]
Unrecognized = 0,

[EnumMember(Value = "unknown_issue_with_acs_access_group")]
UnknownIssueWithAcsAccessGroup = 1,

[EnumMember(Value = "being_deleted")]
BeingDeleted = 2,
}

[DataMember(Name = "created_at", IsRequired = false, EmitDefaultValue = false)]
public string? CreatedAt { get; set; }

[DataMember(Name = "message", IsRequired = false, EmitDefaultValue = false)]
public string? Message { get; set; }

[DataMember(Name = "warning_code", IsRequired = false, EmitDefaultValue = false)]
public AcsAccessGroupWarnings.WarningCodeEnum? WarningCode { get; set; }

public override string ToString()
{
JsonSerializer jsonSerializer = JsonSerializer.CreateDefault(null);

StringWriter stringWriter = new StringWriter(
new StringBuilder(256),
System.Globalization.CultureInfo.InvariantCulture
);
using (JsonTextWriter jsonTextWriter = new JsonTextWriter(stringWriter))
{
jsonTextWriter.IndentChar = ' ';
jsonTextWriter.Indentation = 2;
jsonTextWriter.Formatting = Formatting.Indented;
jsonSerializer.Serialize(jsonTextWriter, this, null);
}

return stringWriter.ToString();
}
}

}
